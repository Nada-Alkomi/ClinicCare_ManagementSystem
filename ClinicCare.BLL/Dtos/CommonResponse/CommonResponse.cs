namespace ClinicCare.BLL.Dtos.CommonResponse;

public class CommonResponse
{
   
    public string Message { get; set; }=string.Empty;
    public bool IsSuccess { get; set; }
    public object AdditionalInfo{ get; set; }=new();
    public List<String> Errors { get; set; }
    
    public CommonResponse(string _message,bool _isSuccess,List<string>errors=null!,object _additionalInfo=null!)
    {
        Message = _message;
        IsSuccess = _isSuccess;
        AdditionalInfo = _additionalInfo;
    }
    
}