using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Guestbook.ModelBinders;

namespace Guestbook.Models
{
    [System.Web.Http.ModelBinding.ModelBinder(typeof(MsgBinder))]
    public class Msg
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [StringLength(15, ErrorMessage = "от 2 до 15 символов", MinimumLength = 2)]
        [DisplayName("Имя")]
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [StringLength(50, ErrorMessage = "от 6 до 50 символов", MinimumLength = 6)]
        [EmailAddress(ErrorMessage = "некорректный Email")]
        public string Email { get; set; }

        /// <summary>
        /// Домашняя страница
        /// </summary>
        [StringLength(100, ErrorMessage = "от 6 до 100 символов", MinimumLength = 6)]
        [DisplayName("Домашняя страница")]
        [DataType(DataType.Url)]
        public string HomePage { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [StringLength(10000, ErrorMessage = "от 10 до 10000 символов", MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Текст")]
        public string Text { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime Date { get; set; }
    }
}