using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddElementToFilterName.Entities
{
    public static class DbSeeder
    {
        public static void SeedAll(EFContext context) 
        {
            SeedFilter(context);
        }

        private static void SeedFilter(EFContext context) 
        {
            string[] filterNames = { "Програмування", "Дизайн" };

            foreach (var item in filterNames) 
            {
                if (context.FilterNames.SingleOrDefault(x => x.Name == item) == null) 
                {
                    context.FilterNames.Add(new FilterName
                    {
                        Name = item
                    }) ;

                    context.SaveChanges();
                }
            }

            List<string[]> filterValuesTwoArr = new List<string[]> 
            {
                new string[] { "C#", "Java", "PHP" },
                new string[] { "Photoshop", "Ilustrator", "Paint3D" }
            };

            foreach (var vymir in filterValuesTwoArr) 
            {
                foreach (var item in vymir) 
                {
                    if (context.FilterValues.SingleOrDefault(x => x.Name == item) == null) 
                    {
                        context.FilterValues.Add(new FilterValue { 
                            Name = item
                        });

                        context.SaveChanges();
                    }
                }
            }

            for (int i = 0; i < filterNames.Length; i++) 
            {
                var filterNameId = context.FilterNames.SingleOrDefault(x => x.Name == filterNames[i]).Id;
                foreach (var value in filterValuesTwoArr[i]) 
                {
                    var filterValueId = context.FilterValues.SingleOrDefault(x => x.Name == value).Id;
                    if (context.FilterNameValues
                        .SingleOrDefault(x => x.FilterNameId == filterNameId && 
                        x.FilterValueId == filterValueId) == null) 
                    {
                        context.FilterNameValues.Add(new FilterNameValue { 
                            FilterNameId = filterNameId,
                            FilterValueId = filterValueId
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
