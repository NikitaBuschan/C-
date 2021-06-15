using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Model
{
    public interface IForbiddenWordsModel
    {
        List<string> Wrods { get; set; }
    }
}
