using System;
using System.Collections;
using System.Reflection;

namespace JsonParser
{
    /*public class ObjectProxy : System.Reflection.DispatchProxy
    {
        internal JsonObject _o;
        
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            string methodName = targetMethod.Name;

            if (methodName.StartsWith("get_") )
            {
                object value = _o[methodName.Substring(4)];

                if ()
                {
                    return value;
                }
                else if (value is JsonObject o)
                {
                    ObjectProxy proxy = (ObjectProxy)DispatchProxy.Create(targetMethod.ReturnType, typeof(ObjectProxy));
                    proxy._o = o;
                    return proxy;
                }
                else if(value is JsonArray a)
                {
                    if (targetMethod.ReturnType.IsAssignableTo(typeof(IEnumerable)))
                    {
                        return a;
                    }
                    
                    
                }

                throw new NotImplementedException();
            }
            else if (methodName.StartsWith("set_"))
            {
                
            }
        }
    }*/
}