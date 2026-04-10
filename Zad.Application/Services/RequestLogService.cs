using Zad.Application.Interfaces;
using Zad.Domain.Entities;
using Zad.Domain.Enums;

namespace Zad.Application.Services;

public class RequestLogService : IRequestLogService
{
    private readonly IUnitOfWork _unitOfWork;

    public RequestLogService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task LogRequest(int userId, ChatMode mode, RequestStatus status)
    {
        var requestLog = new RequestLog
        {
            UserId = userId,
            Mode = mode,
            Status = status
        };

        await _unitOfWork.RequestLogs.AddAsync(requestLog);
        await _unitOfWork.SaveChangesAsync();
    }
}
