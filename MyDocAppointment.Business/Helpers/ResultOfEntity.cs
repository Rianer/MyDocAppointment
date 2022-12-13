namespace MyDocAppointment.Business.Helpers
{
    public class Result<TEntity>
    {
        public TEntity? Entity { get; set; }

        public string Error { get; private set; } = string.Empty;
        public bool IsSuccess { get; private set; }
        public bool IsFailure { get; private set; }

        public static Result<TEntity> Success(TEntity entity)
        {
            return new Result<TEntity>
            {
                Entity = entity,
                IsSuccess = true
            };
        }

        public static Result<TEntity> Failure(string error)
        {
            return new Result<TEntity>
            {
                Error = error,
                IsFailure = true
            };
        }
    }
}
