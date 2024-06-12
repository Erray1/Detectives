using Ardalis.Result;

namespace Detectives.GameService.Domain.Services;
public static class GameConnectionValidator
{
    public static Result Validate(GameState gameState, string connectionToken, string userId)
    {
        bool gameHasPendingUser = gameState.PendingUsers.Any(x => x.ConnectionToken == connectionToken && x.UserId == userId);
        if (!gameHasPendingUser)
        {
            return Result.Error("Неверный токен");
        }

        bool gameIsInWaitingState = gameState.IsOpen;
        if (!gameIsInWaitingState)
        {
            return Result.Error("Игра уже началась");
        }

        bool gameIsNotFull = gameState.ConnectedUsers.Count < gameState.MaxPlayers;
        if (!gameIsNotFull)
        {
            return Result.Error("Максимальное количество игроков");
        }

        return Result.Success();
    }
}

