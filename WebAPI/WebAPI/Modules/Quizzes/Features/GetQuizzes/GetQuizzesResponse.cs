using WebAPI.BL.Models.Quiz;
using WebAPI.Core.Models;

namespace WebAPI.Modules.Quizzes.Features.GetQuizzes;

public record GetQuizzesResponse(int TotalCount, IReadOnlyList<QuizDto> Data) : BasePaginatedResponse<QuizDto>(TotalCount, Data);