namespace ToToAirline.BaseResponses
{
    public class BaseResponse<TEntity>
    {
        public BaseResponse(bool status, string code, string msg, TEntity data)
        {
            Status = status;
            Code = code;
            Msg = msg;
            Data = data;
        }

        public bool Status { get; set; }
        public string Code { get; set; }
        public string Msg { get; set; }
        public TEntity Data { get; set; }
    }
    public class BaseResponse
    {
        public BaseResponse(bool status, string code, string msg)
        {
            Status = status;
            Code = code;
            Msg = msg;
        }
      

        public bool Status { get; set; }
        public string Code { get; set; }
        public string Msg { get; set; }
    }

}
