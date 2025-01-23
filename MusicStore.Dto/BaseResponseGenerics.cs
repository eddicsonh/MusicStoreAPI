namespace MusicStore.Dto
{
    public class BaseResponseGenerics<T> : BaseResponse
    {
        public T? Data{ get; set; }
    }
}
