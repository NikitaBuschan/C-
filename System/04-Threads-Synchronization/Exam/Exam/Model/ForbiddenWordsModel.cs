using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Model
{
    public class ForbiddenWordsModel : IForbiddenWordsModel
    {
        public List<string> Wrods { get; set; }
    }
}
