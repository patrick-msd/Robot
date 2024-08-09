using Microsoft.EntityFrameworkCore;
using PSGM.Model.DbWorkflow;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public List<DbWorkflow_WorkflowItemLink> Database_LoadData_V1_0_0(Guid? WorkflowId)
        {
            return _dbWorkflow_Context.WorkflowItemLinks.Where(p => p.WorkflowId == WorkflowId)
                                                        .OrderBy(p => p.Order)
                                                        .Include(p => p.WorkflowItem)
                                                        .ToList();
        }
    }
}
