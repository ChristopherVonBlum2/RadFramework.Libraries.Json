using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string myJson = @"
            { ""prop"" : ""test"",
              prop2 : { prop1 : ""test nested prop"" },
              prop3 : [ { prop1 : ""test in array"" }, ""string"", [ ""another array"" ] } ] } 
";
            
            var testObject = new JsonObject(myJson);
            var testprop = testObject["prop"];
            
            var testprop3 = ((JsonArray)testObject["prop3"]).ToList();

            
            string arrayString = "[ \"test string\", { prop1 : \"test prop1\" }, [ \"test in inner array\" ] ]";

            var arr = new JsonArray(arrayString);

            var entries = arr.ToList();

            var o = ((JsonObject)entries[1])["prop1"];

            ;
        }
    }
}