using WebAPI.BL.Models.Questions;
using WebAPI.Core.Models;

namespace WebAPI.Modules.Questions.Features.GetQuestions;

public record GetQuestionsResponse(int TotalCount, IReadOnlyList<QuestionDto> Data) : BasePaginatedResponse<QuestionDto>(TotalCount, Data);