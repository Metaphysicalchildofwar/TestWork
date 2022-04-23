using TestWork.Dto.Base;

namespace TestWork.Dto.Objects
{
    public class ObjectWithoutIdDto : BaseModelWithoutIdDto
    {
        public BaseModelDto DesignObject { get; set; }
    }
}
