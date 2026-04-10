using Zad.Application.DTOs;
using Zad.Domain.Enums;

namespace Zad.Application.Interfaces;

public interface IQuestionService
{
    Task<MessageDto> AskQuestion(int userId, int chatSessionId, string question, ChatMode mode, ExpertSubMode? subMode);
    Task<string?> GetAnswer(int messageId);
    string BuildPrompt(string question, ChatMode mode, IReadOnlyList<int>? context);
}
