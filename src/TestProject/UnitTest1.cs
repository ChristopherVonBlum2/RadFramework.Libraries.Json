using System.Linq;
using JsonParser;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParseComplexObject()
        {
            string myJson = @"
            { ""prop"" : ""test"",
              prop2 : { prop1 : ""test nested prop"" },
              prop3 : [ { prop1 : ""test in array"" }, ""string"", [ ""another array"" ] } ] } 
";
            
            var testObject = new JsonObject(myJson);
            
            Assert.IsTrue(((string)testObject["prop"]) == "test");
            Assert.IsTrue(((string)((JsonObject)testObject["prop2"])["prop1"]) == "test nested prop");
            
            JsonArray prop3 = (JsonArray)testObject["prop3"];
            
            Assert.IsTrue(((string)((JsonObject)prop3[0])["prop1"]) == "test in array");
            Assert.IsTrue(((string)prop3[1]) == "string");
            Assert.IsTrue(((string)((JsonArray)prop3[2])[0]) == "another array");
        }

        [Test]
        public void ParseNestedObject()
        {
            string json = "{ prop1 : { prop1 : { str : \"test\" } } }";

            JsonObject o1 = new JsonObject(json);

            JsonObject o2 = (JsonObject)o1["prop1"];
            
            JsonObject o3 = (JsonObject)o2["prop1"];
            
            string str = (string)o3["str"];
            
            Assert.IsTrue(str == "test");
        }

        [Test]
        public void ParseMixedArray()
        {
            string arrayString = "[ \"test string\", { prop1 : \"test prop1\" }, [ \"test in inner array\" ] ]";

            var arr = new JsonArray(arrayString);

            var entries = arr.ToList();

            Assert.IsTrue((string)entries[0] == "test string");
            Assert.IsTrue(((string)((JsonObject)entries[1])["prop1"]) == "test prop1");
            Assert.IsTrue(((string)((JsonArray)entries[2])[0]) == "test in inner array");
        }
        
    }
}