using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLaDE
{
    public class Documentation
    {
        public List<DocCategory> Categories = new List<DocCategory>();

        public DocCategory SelectCategoryByName(string name)
        {
            foreach (DocCategory category in Categories)
            {
                if (category.CategoryName == name)
                {
                    return category;
                }
            }

            return null;
        }

        public void EditFunction(DocFunction editedfunc)
        {
            Categories.ForEach(cat =>
            {
                cat.Functions.ForEach(elem =>
                {
                    if (elem.Name == editedfunc.Name)
                    {
                        elem.Description = editedfunc.Description;
                        elem.Examples = editedfunc.Examples;
                    }
                });
            });

        }
    }
    public class DocCategory
    {
        public string CategoryName = "";
        public List<DocFunction> Functions = new List<DocFunction>();

        public List<DocFunction> FilterFunctions(string filter)
        {
            IEnumerable<DocFunction> funcs = Functions.Where(elem => elem.Name.ToLower().Contains(filter.ToLower()));
            return funcs.ToList<DocFunction>();
        }

        public DocFunction SelectFunctionByName(string name)
        {
            foreach (DocFunction func in Functions)
            {
                if (func.Name == name)
                {
                    return func;
                }
            }

            return null;
        }
    }

    public class DocFunction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Examples { get; set; }
    }
}

