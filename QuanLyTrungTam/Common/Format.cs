using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Common
{
    public class Format
    {
        public static string FormatCurrencyVND(decimal? price)
        {
            return price != null ? price.Value.ToString("#,##").Replace(',', '.') + " VNĐ" : "";
        }

        public static string FormatDateTime(DateTime dateTime)
        {
            return "Ngày " + dateTime.Day.ToString() + ", tháng "
                        + dateTime.Month.ToString() + ", năm "
                        + dateTime.Year.ToString() + ", giờ "
                        + dateTime.Hour.ToString() + ", phút"
                        + dateTime.Minute.ToString();

        }

        public static string FormatDate(DateTime dateTime)
        {
            return dateTime.Day.ToString() + "/"
                        + dateTime.Month.ToString() + "/"
                        + dateTime.Year.ToString();

        }
    }
}