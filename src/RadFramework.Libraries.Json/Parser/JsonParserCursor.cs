using System.Collections.Generic;
using System.Text;

namespace JsonParser
{
    public class JsonParserCursor
    {
        public string CurrentJson
        {
            get
            {
                return Json.Substring(Index);
            }
        }

        public char CurrentChar
        {
            get
            {
                return Json[Index];
            }
        }

        public string Json { get; set; }
        
        public int Index { get; set; }

        public JsonParserCursor(string json, int index)
        {
            Json = json;
            Index = index;
        }
        
        public void SkipObjectOrArray()
        {
            if (!(CurrentChar.Equals('{') || CurrentChar.Equals('[')))
            {
                throw new ParserBugException("Expected char is { or [");
            }
            
            int nesting = 0;
            
            do
            {
                if (CurrentChar.Equals('{') || CurrentChar.Equals('['))
                {
                    nesting++;
                }
                else if (CurrentChar.Equals('}') || CurrentChar.Equals(']'))
                {
                    nesting--;
                }
                else if (CurrentChar.Equals('\"'))
                {
                    SkipString();
                }
                else if (CurrentChar.Equals(' '))
                {
                    SkipWhitespacesAndNewlines();
                    continue;
                }
                
                Index++;
                
            } while (nesting != 0);
        }
        
        public void SkipWhitespacesAndNewlines()
        {
            while (CurrentChar.Equals(' ') || CurrentChar.Equals('\n') || CurrentChar.Equals('\r'))
            {
                Index++;
            }
        }
        
        public string ReadString()
        {
            if (!CurrentChar.Equals('"'))
            {
                throw new ParserBugException("Expected char is \"");
            }
            
            Index++;

            StringBuilder builder = new StringBuilder();
            
            while(true)
            {
                if (CurrentChar == '"' 
                    && (Index != 0 && Json[Index - 1] != '\\'))
                {
                    break;
                }

                builder.Append(CurrentChar);
                
                Index++;
            }
            
            Index++;

            return builder.ToString();
        }
        
        public void SkipString()
        {
            if (!CurrentChar.Equals('"'))
            {
                throw new ParserBugException("Expected char is \"");
            }
            
            // skip first "
            Index++;
            
            while(true)
            {
                if (CurrentChar == '"' 
                    && (Index != 0 && Json[Index - 1] != '\\'))
                {
                    break;
                }
                
                Index++;
            }
            
            Index++;
        }
    }
}