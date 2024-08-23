using CSharpFunctionalExtensions;
using DDDRefactor.Enums;

namespace DDDRefactor.Models.ValueObjects
{
    /// <summary>
    /// Права доступа пользователя
    /// </summary>
    public class UserPermissions : ValueObject
    {
        /// <summary>
        /// Права доступа
        /// </summary>
        public AccessRights Rights { get; private set; }

        private UserPermissions(AccessRights accessRights) => Rights = accessRights;

        private UserPermissions()
        {
            
        }
        /// <summary>
        /// Задать права пользователю
        /// </summary>
        /// <param name="rights"></param>
        /// <returns></returns>
        public static Result<UserPermissions> Create(AccessRights rights)
        {
            if (rights == AccessRights.None)
                return Result.Failure<UserPermissions>($"Невозможно создать пользователя без прав!");

            return new UserPermissions(rights);
        }

        /// <summary>
        /// Добавление прав
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public UserPermissions AddRight(AccessRights right)
        {
            return Create(Rights | right).Value;
        }

        /// <summary>
        /// Метод для удаления прав
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public UserPermissions RemoveRight(AccessRights right)
        {
            return Create(Rights & ~right).Value;
        }

        /// <summary>
        /// Проверка наличия конкретного права
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool HasRight(AccessRights right)
        {
            return Rights.HasFlag(right);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Rights;
        }
    }
}
