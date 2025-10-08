using System.Reflection;

namespace Tester
{
    internal static class Utils
    {
        static readonly Type[] types = typeof(Program).Assembly.GetTypes();
        static readonly BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

        public static readonly Type[] enums = types.Where(x => x.IsEnum).ToArray();
        public static readonly Type[] classes = types.Where(x => x.IsClass).ToArray();



        public static bool IsPascalCase(this Type typeToCheck) => typeToCheck.Name.IsPascalCase();
        public static bool IsPascalCase(this string textToCheck)
        {
            return char.IsLetter(textToCheck[0]) && char.IsUpper(textToCheck[0]);
        }

        public static bool IsCamelCase(this string textToCheck)
        {
            return char.IsLetter(textToCheck[0]) && char.IsLower(textToCheck[0]);
        }

        public static bool IsStatic(this Type typeToCheck) => typeToCheck.IsAbstract && typeToCheck.IsSealed;
        public static bool IsProperlyAbstract(this Type typeToCheck) => typeToCheck.IsAbstract && !typeToCheck.IsSealed;

        public static bool IsNullable(this Type typeToCheck) => Nullable.GetUnderlyingType(typeToCheck) != null;

        public static FieldInfo[] GetAllFields(this Type typeToCheck) => typeToCheck.GetFields(flags);
        public static PropertyInfo[] GetAllProperties(this Type typeToCheck) => typeToCheck.GetProperties(flags);
        public static ConstructorInfo[] GetAllConstructors(this Type typeToCheck) => typeToCheck.GetConstructors(flags);
        public static MethodInfo[] GetAllMethods(this Type typeToCheck) => typeToCheck.GetMethods(flags);

        public static bool IsTypeUsed(this Type typeToCheck)
        {
            if (typeToCheck.IsStatic())
                return true;

            foreach (var classType in classes)
            {
                // Used by any field
                if (classType.GetAllFields().Any(x => x.FieldType == typeToCheck))
                    return true;

                // Used by any property
                if (classType.GetAllProperties().Any(x => x.PropertyType == typeToCheck))
                    return true;

                // Used by any constructor
                foreach (var constructor in classType.GetAllConstructors())
                {
                    if (constructor.GetParameters().Any(x => x.ParameterType == typeToCheck))
                        return true;
                }

                // Used by any methods
                foreach (var method in classType.GetAllMethods())
                {
                    if (method.ReturnType == typeToCheck)
                        return true;
                    if (method.GetParameters().Any(x => x.ParameterType == typeToCheck))
                        return true;
                }
            }
            return false;
        }
    }
}
