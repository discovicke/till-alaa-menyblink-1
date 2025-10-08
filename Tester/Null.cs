using System.Reflection;

namespace Tester
{
    [TestClass]
    public sealed class Null
    {
        [TestMethod("Används av minst ett fält eller en returtyp")]
        public void HasAtLeastOne()
        {
            int nullables = 0;
            foreach (var classType in Utils.classes)
            {
                foreach (var field in classType.GetAllFields())
                {
                    if (field.CustomAttributes.Any(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.NullableAttribute"))
                    {
                        nullables++;
                    }
                    else if (field.FieldType.IsNullable())
                    {
                        nullables++;
                    }
                }

                foreach (var method in classType.GetAllMethods())
                {
                    if (IsNullableMethodReturnType(method))
                    {
                        nullables++;
                    }
                }
            }

            if (nullables == 0)
            {
                Assert.Fail("Det finns inga fält eller returtyper som kan vara null");
            }
        }

        static bool IsNullableMethodReturnType(MethodInfo method)
        {
            // Hail mary
            if (method.ReturnType.IsNullable())
            {
                return true;
            }

            // Ok then...
            foreach (var attribute in method.CustomAttributes)
            {
                if (attribute.AttributeType.FullName != "System.Runtime.CompilerServices.NullableContextAttribute")
                    continue;

                if (attribute.ConstructorArguments.Count < 0)
                    continue;

                var arg = attribute.ConstructorArguments[0];
                if ((byte)arg.Value! == 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
