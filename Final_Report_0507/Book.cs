using System;
using System.Collections.Generic;

namespace Final_Report_0507
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Publisher { get; set; } = "";
        public DateTime PublishDate { get; set; }
        public string AgeRating { get; set; } = "普遍級";

        public string Status
        {
            get
            {
                return string.IsNullOrWhiteSpace(Borrower) ? "可借閱" : "已借出";
            }
        }

        public string? Borrower { get; set; } = null;
        public string ReservationUserId { get; set; } = "";
    }
}
