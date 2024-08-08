using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileViewer.Model
{
    public class Parser
    {
        private (int, string) GetDocumentId(string content, List<Document> documents, List<Segment> segments, List<Element> elements)
        {
            if (content == null || content == string.Empty || content.Substring(0, 3) != "SYS")
            {
                throw new Exception("Can not find SYS segment.");
            }
            var docIds = documents
                .Select(x => x.Id)
                .ToList();
            var sysSegmentIds = segments
                .Where(x => docIds.IndexOf(x.DocumentId) != -1 && x.Name == "SYS")
                .Select(x => x.Id)
                .ToList();
            var sysElement = elements
                .Where(x => docIds.IndexOf(x.Document) != -1 && sysSegmentIds.IndexOf(x.SegmentId) != -1);
            foreach (var doc in documents)
            {
                var eachEleDoc = sysElement
                    .Where(x => x.Document == doc.Id && x.Name == "TYPEDOCUMENT")
                    .FirstOrDefault();
                var docIdFromContent = content.Substring(eachEleDoc.StartAt - 1, eachEleDoc.Length);
                if (docIdFromContent.Trim() == doc.DocType.ToString())
                {
                    return (doc.Id, doc.DocType);
                }
            }
            return (-1, "-1");
        }

        public (List<SegmentContent>, int) ParseContent(string content)
        {
            List<Document> documents = SchemaModel.LoadDocumentFromLib();
            List<Segment> segments = SchemaModel.LoadSegmentFromLib();
            List<Element> elements = SchemaModel.LoadElementFromLib();
            var (documentId, docType) = GetDocumentId(content, documents, segments, elements);
            if (documentId == -1)
            {
                throw new Exception("Document is not defined");
            }
            List<SegmentContent> documentContent = new List<SegmentContent>();
            List<int> arrGroupId = new List<int>();
            List<ParentGroup> arrParentGroupId = new List<ParentGroup>();
            var lineEleNum = 1;
            var parentId = 1;
            //Group
            Group recordGroup = null;
            var groupId = 0;
            var groupSequence = 1;
            var groupLevel = 0;
            var lastGroupId = -1;
            var parentGroupId = -1;

            //segment
            Segment recordSegment = null;
            var segmentName = "";
            var segmentId = 0;
            var segmentSequence = 0;
            var firstSegment = 0;
            var lastFirstSegment = 0;
            var lastSegmentName = "";
            List<Group> groups = SchemaModel.LoadGroupFromLib()
                .Where(x => x.DocumentId == documentId)
                .ToList();
            segments = segments.Where(x => x.DocumentId == documentId).ToList();
            elements = elements.Where(x => x.Document == documentId).ToList();
            var arrContent = content.Split('\n');
            int max = 1;
            int lenMaxOfSegmentName = _findMaxLenOfSegmentName(elements);
            for (var i = 0; i < arrContent.Length; i++)
            {
                int currLen = lenMaxOfSegmentName;
                var lineContent = arrContent[i];
                if (lineContent.Trim() == string.Empty) continue;
                if (currLen > lineContent.Trim().Length) currLen = lineContent.Trim().Length;
                if (i == 0) segmentName = "SYS";
                else
                {                    
                    segmentName = lineContent.Substring(0, currLen).Trim();
                    if(segmentName.IndexOf(' ') > 0)
                    {
                        segmentName = segmentName.Substring(0, segmentName.IndexOf(' '));
                    }
                }
                recordSegment = segments.Where(x => x.Name == segmentName).FirstOrDefault();
                if (recordSegment == null)
                {
                    if (recordSegment == null)
                    {
                        throw new Exception($"Segment {segmentName.Trim()} does not exist.");
                    }
                }
                groupId = recordSegment.GroupId;
                segmentId = recordSegment.Id;
                recordGroup = groups.Where(x => x.Id == groupId).FirstOrDefault();
                if (recordSegment == null)
                {
                    throw new Exception($"Group id {groupId} not found.");
                }
                var elementContents = new List<ElementContent>();
                var elementOfSegment = elements.Where(x => x.SegmentId == segmentId).ToList();
                firstSegment = recordSegment.FirstSegment;// value: 0,1,2
                groupLevel = recordGroup.Level;
                parentGroupId = recordGroup.Parent;
                groupSequence = GetGroupSequence(recordGroup, arrGroupId,
                    groupId, lastGroupId, groupSequence,
                    firstSegment, lastFirstSegment);
                segmentSequence = GetSegmentSequence(segmentName, firstSegment, lastSegmentName, segmentSequence);
                if (firstSegment == 1)
                {
                    parentId = lineEleNum;
                    if (arrParentGroupId.Count > 0)
                    {
                        var parentGroupIdTemp = arrParentGroupId
                            .Where(x => x.groupId == parentGroupId && parentGroupId != -1)
                            .ToArray();
                        if (parentGroupIdTemp.Length > 0) parentId = parentGroupIdTemp[parentGroupIdTemp.Length - 1].parentGroupId;
                    }
                    else
                    {
                        arrParentGroupId.Add(new ParentGroup
                        {
                            groupId = groupId,
                            parentId = parentId,
                            parentGroupId = parentGroupId
                        });
                    }
                }
                for (var j = 0; j < elementOfSegment.Count; j++)
                {
                    var ele = elementOfSegment[j];
                    var startAt = ele.StartAt - 1;
                    var len = ele.Length;
                    string elementValue = string.Empty;
                    if (startAt + len > lineContent.Length)
                    {
                        len = lineContent.Length - startAt;
                    }
                    if (len > 0)
                        elementValue = lineContent.Substring(startAt, len);//.Trim();
                    //insert content row
                    elementContents.Add(new ElementContent
                    {
                        Id = lineEleNum++,
                        LineNum = i,
                        ParentId = parentId,
                        DocumentId = documentId,
                        DocType = docType,
                        ParentGroupId = parentGroupId,
                        GroupId = groupId,
                        GroupName = recordGroup.Name,
                        GroupLevel = groupLevel,
                        GroupSequence = groupSequence,
                        SegmentId = segmentId,
                        SegmentSequence = segmentSequence,
                        ElementId = ele.Id,
                        ElementValue = elementValue,
                        ElementName = ele.Name,
                        SegmentName = segmentName,
                        StartAt = ele.StartAt,
                        Length = ele.Length
                    });
                }
                //backup last value
                lastGroupId = groupId;
                lastFirstSegment = firstSegment;
                lastSegmentName = segmentName;
                if (arrGroupId.IndexOf(groupId) == -1)
                {
                    arrGroupId.Add(groupId);
                }
                if (max < elementContents.Count) max = elementContents.Count;
                documentContent.Add(new SegmentContent
                {
                    Index = i,
                    SegmentName = segmentName,
                    Elements = elementContents
                });
            }
            return (documentContent, max);
        }
        private int _findMaxLenOfSegmentName(List<Element> elements)
        {
            var max = 1;
            var firstSeg = elements[0].SegmentId;
            var num = (elements.Count + firstSeg);
            for (var segId = firstSeg; segId < num; segId++)
            {
                var firstElement = elements.Where(x => x.SegmentId == segId).FirstOrDefault();
                if (firstElement == null)
                    return max;
                if (max < firstElement.StartAt - 1)
                    max = firstElement.StartAt - 1;
            }
            return max;           
        }

        private int GetSegmentSequence(string segmentName, int firstSegment, string lastSegmentName, int segmentSequence)
        {
            if (firstSegment == 1 || firstSegment == 2)
            {
                segmentSequence = 1;
                return segmentSequence;
            }
            else if (firstSegment == 0)
            {
                if (lastSegmentName == segmentName)
                {
                    segmentSequence++;
                }
                else
                    segmentSequence = 1;

            }
            return segmentSequence;
        }

        private int GetGroupSequence(Group group, List<int> arrGroupId, int groupId, int lastGroupId, int groupSequence,
                              int firstSegment, int lastFirstSegment)
        {
            if (firstSegment == 1)
            {
                if (lastGroupId == groupId)
                {
                    groupSequence++;
                }
                else
                {
                    //vefify all parents of last groupid, if find a match->increment sequence, else set sequence = 1
                    if (arrGroupId.IndexOf(groupId) != -1)
                    {
                        groupSequence++;
                    }
                    else
                    {
                        groupSequence = 1;
                    }
                }
            }
            else if (firstSegment == 0)
            {
                // take group sequence of last line
                return groupSequence;
            }
            else if (firstSegment == 2)
            {
                if (lastGroupId != groupId)
                {
                    groupSequence = 1;
                }
                else if (lastGroupId == groupId && lastFirstSegment == 2)
                {
                    groupSequence++;
                }
                else if (lastGroupId == groupId && lastFirstSegment == 1)
                {
                    return groupSequence;
                }
            }
            return groupSequence;
        }
    }

    public class ParentGroup
    {
        public int groupId { get; set; }
        public int parentId { get; set; }
        public int parentGroupId { get; set; }
    }
}
