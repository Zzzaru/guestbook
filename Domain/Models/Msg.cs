using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Msg
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(15)]
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Домашняя страница
        /// </summary>
        [StringLength(100)]
        public string HomePage { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        [Required]
        [StringLength(40)]
        public string Ip { get; set; }

        /// <summary>
        /// Браузер
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Browser { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime Date { get; set; }
    }
}
