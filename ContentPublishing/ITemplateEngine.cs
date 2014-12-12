using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Publishing
{
    public interface ITemplateEngine
    {
        bool CanProcess(string inputType, string outputType);

        string Process(string contents, IDictionary<string, dynamic> attributes);
    }
}
