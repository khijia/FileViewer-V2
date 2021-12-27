using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileViewer.Model
{
    public static class SchemaModel
    {        
        public static List<Document> LoadDocumentFromLib()
        {
            using (StreamReader r = new StreamReader(CONS.documentFile))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Document>>(json);
            }
        }
        public static List<Group> LoadGroupFromLib()
        {
            using (StreamReader r = new StreamReader(CONS.groupFile))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Group>>(json);
            }
        }

        public static List<Segment> LoadSegmentFromLib()
        {
            using (StreamReader r = new StreamReader(CONS.segmentFile))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Segment>>(json);
            }
        }

        public static List<Element> LoadElementFromLib()
        {
            using (StreamReader r = new StreamReader(CONS.elementFile))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Element>>(json);
            }
        }

        public static List<Group> LoadGroupsByDocumentId(int documentId)
        {
            return LoadGroupFromLib()
                .Where(x => x.DocumentId == documentId)
                .ToList();
        }
        public static List<Segment> LoadSegmentByDGId(int documentId, int groupId)
        {
            return LoadSegmentFromLib()
                .Where(x => x.DocumentId == documentId && (x.GroupId == groupId || groupId == -1))
                .ToList();
        }
        public static List<Element> LoadElementsByDGE(int documentId, List<int> segmentId)
        {
            return LoadElementFromLib()
                  .Where(x => x.Document == documentId && ((segmentId.IndexOf(x.SegmentId) != -1) || segmentId[0] == -1))
                .ToList();
        }
        public static List<Element> LoadElementById(int documentId, int groupId, List<int> segmentId, int elementId)
        {
            var lstElements = LoadElementFromLib().Where(x => x.Document == documentId).ToList();
            if (elementId == -1)
            {
                if (segmentId[0] == -1)
                {
                    if (groupId == -1)
                    {
                        return lstElements;
                    }
                }
                else
                {
                    return lstElements.Where(x => segmentId.IndexOf(x.SegmentId) != -1).ToList();
                }
            }
            else
                return lstElements.Where(x => x.Id==elementId).ToList();
            return new List<Element>();

        }
        
        public static void SaveGroup(List<Group> lst)
        {
            string json = JsonConvert.SerializeObject(lst.ToArray());
            File.WriteAllText(CONS.groupFile, json);
        }
        public static void SaveSegment(List<Segment> lst)
        {
            string json = JsonConvert.SerializeObject(lst.ToArray());
            File.WriteAllText(CONS.segmentFile, json);
        }
        public static void SaveElement(List<Element> lst)
        {
            string json = JsonConvert.SerializeObject(lst.ToArray());
            File.WriteAllText(CONS.elementFile, json);
        }
        public static void SaveDocument(List<Document> lst)
        {
            string json = JsonConvert.SerializeObject(lst.ToArray());
            File.WriteAllText(CONS.documentFile, json);
        }

        public static List<DataSetting> LoadDataSettings()
        {
            using (StreamReader r = new StreamReader(CONS.settingsFile))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<DataSetting>>(json);               
            }
        }
        public static void SaveDataSettings(List<DataSetting> lst)
        {
            string json = JsonConvert.SerializeObject(lst.ToArray());
            File.WriteAllText(CONS.settingsFile, json);
        }
        public static List<TabConfig> LoadTabOpen()
        {
            if (!File.Exists(CONS.configFile)) return new List<TabConfig>();
            using (StreamReader r = new StreamReader(CONS.configFile))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<TabConfig>>(json);
            }
        }
        public static void SaveTabOpen(List<TabConfig> lst)
        {
            string json = JsonConvert.SerializeObject(lst.ToArray());
            File.WriteAllText(CONS.configFile, json);
        }
    }
    public class DataSchema
    {
        public int No { get; set; }
        //public int DocumentId { get; set; }
        public string GroupName { get; set; }
        public string SegmentName { get; set; }
        public string Name { get; set; }
        public string Usage { get; set; }
        //public int Parent { get; set; }
        public int Length { get; set; }
        public int StartAt { get; set; }
        public string Description { get; set; }

    }

    public class DataDocument
    {
        public int Id { get; set; }
        public int DocType { get; set; }
        public string Description { get; set; }
    }

    public class DataSetting
    {
        public Erp erp { get; set; }
        public string account { get; set; }
        public AuthType authType { get; set; }
        public string url { get; set; }
        public BasicAuth basicAuth { get; set; }
        public oAuth oAuth { get; set; }
    }
    public class TabConfig
    {
        public string TabName { get; set; }
        public string FileTempPath { get; set; }
        public string FilePath { get; set; }
        public bool IsActive { get; set; } = false;
    }

    public static class CONS
    {
        public static readonly string path = Path.GetTempPath();
        public static readonly string configFile = $@"{path}ALCFileViewer/Configs.json";
        public static readonly string dataFolder =  $@"{path}ALCFileViewer/Data";
        public static readonly string settingsFile = $@"{path}ALCFileViewer/Data/Settings.json";
        public static readonly string documentFile = $@"{path}ALCFileViewer/Data/Document.json";
        public static readonly string groupFile = $@"{path}ALCFileViewer/Data/Group.json";
        public static readonly string segmentFile = $@"{path}ALCFileViewer/Data/Segment.json";
        public static readonly string elementFile = $@"{path}ALCFileViewer/Data/Element.json";
    }
    
}
