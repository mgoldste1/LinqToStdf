
using LinqToStdf.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LinqToStdf
{
    /// <summary>
    /// This class allows you to feed in a record type and variable name from the spec and get the variable name in this parser.  
    /// This is useful if you have config files that are based off of spec names that may change.
    /// </summary>
    public class ClassVariableMapping
    {
        private static volatile ClassVariableMapping? instance;
        private static Dictionary<string, Dictionary<string, (string varName, Type StdfRecordType, FieldLayoutAttribute fla)>>? vars;
        private const string @namespace = "LinqToStdf.Records.V4.";

        private static object @lock = new();
        private static object mapLock = new();
        private ClassVariableMapping() => vars = new();
        public static ClassVariableMapping get
        {
            get
            {
                if (instance is null)
                    lock (@lock)
                        if (instance is null)
                            instance = new ClassVariableMapping();
                return instance;
            }
        }
        public (string varName, Type type, FieldLayoutAttribute fla) Map(string className, string varTag)
        {
            lock (mapLock)
            {
                className = className.ToUpper();
                if (!vars!.ContainsKey(className))
                    vars.Add(className, new());
                if (!vars[className].ContainsKey(varTag))
                    vars[className].Add(varTag, GetMapping(className, varTag));
            }
            return vars[className][varTag];
        }
        private (string? varName, Type type, FieldLayoutAttribute fla) GetMapping(string className, string varTag)
        {
            Type? t = Type.GetType(@namespace + className,true,true) ?? throw new Exception("Invalid class name");
            varTag = varTag.ToUpper();
            var attributes = t!.GetCustomAttributes(typeof(FieldLayoutAttribute),true).Select(o=>o as FieldLayoutAttribute).ToList();
            var fla = attributes.Where(o => (o != null && !string.IsNullOrEmpty(o.NameInSpec) && o.NameInSpec.ToUpper() == varTag) 
                                         || (o != null && !string.IsNullOrEmpty(o.RecordProperty) && o.RecordProperty.ToUpper() == varTag))
                                .FirstOrDefault() ?? throw new Exception("Invalid Variable tag");
            return (fla.RecordProperty, t, fla);
        }
    }
}
