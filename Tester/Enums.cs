namespace Tester
{
    [TestClass]
    public sealed class Enums
    {
        [TestMethod("Existerar")]
        public void HasAtLeastOne()
        {
            if (Utils.enums.Length == 0)
            {
                Assert.Fail("Du måste deklarera minst 1 enum");
            }
        }

        [TestMethod("Har minst en med tre värden")]
        public void HasAtLeastThreeValues()
        {
            foreach (var enumType in Utils.enums)
            {
                var enumNames = enumType.GetEnumNames();
                if (enumNames.Length >= 3)
                    return;
            }

            Assert.Fail("Du måste deklarera minst en enum som innehåller minst tre värden");
        }

        [TestMethod("Är inte tomma")]
        public void HasNoEmptyEnums()
        {
            var errors = new List<string>();

            foreach (var enumType in Utils.enums)
            {
                var enumNames = enumType.GetEnumNames();
                if (enumNames.Length == 0)
                {
                    errors.Add("enum " + enumType.Name);
                }
            }
            if (errors.Count > 0)
            {
                Assert.Fail($"Det finns {errors.Count} {(errors.Count == 1 ? "enum" : "enums")} som inte har några värden:\n • {string.Join("\n • ", errors)}");
            }
        }


        [TestMethod("Är skrivna i PascalCase")]
        public void HasPascalCase()
        {
            var errors = new List<string>();

            foreach (var enumType in Utils.enums)
                if (!enumType.IsPascalCase())
                    errors.Add("enum " + enumType.Name);

            if (errors.Count > 0)
                Assert.Fail($"Det finns {errors.Count} {(errors.Count == 1 ? "enum" : "enums")} som inte har en stor första bokstav i sitt namn:\n • {string.Join("\n • ", errors)}");
        }

        [TestMethod("Har alla värden skrivna i PascalCase")]
        public void HasPascalCaseValues()
        {
            var errors = new List<string>();

            foreach (var enumType in Utils.enums)
            {
                var enumNames = enumType.GetEnumNames();
                foreach (var enumName in enumNames)
                {
                    if (!char.IsUpper(enumName[0]))
                    {
                        errors.Add($"{enumType.Name}.{enumName}");
                    }
                }
            }
            if (errors.Count > 0)
            {
                Assert.Fail($"Det finns {errors.Count} {(errors.Count == 1 ? "enumvärde" : "enumvärden")} som inte har en stor första bokstav i sitt namn:\n • {string.Join("\n • ", errors)}");
            }
        }

        [TestMethod("Används som fält, parameter eller returtyp")]
        public void IsUsed()
        {
            var errors = Utils.enums
                .Where(enumType => !enumType.IsTypeUsed())
                .Select(x => "enum " + x.Name)
                .ToArray();

            if (errors.Length > 0)
            {
                Assert.Fail($"Det finns {errors.Length} {(errors.Length == 1 ? "enum" : "enums")} som inte används någonstans:\n • {string.Join("\n • ", errors)}");
            }
        }
    }
}
