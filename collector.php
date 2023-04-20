<?php
namespace Collector\Common;
class tarikh
{
    private $WDN = array('ЫЊЪ©ШґЩ†ШЁЩ‡', 'ШЇЩ€ШґЩ†ШЁЩ‡', 'ШіЩ‡ ШґЩ†ШЁЩ‡', 'Ъ†Щ‡Ш§Ш± ШґЩ†ШЁЩ‡', 'ЩѕЩ†Ш¬ШґЩ†ШЁЩ‡', 'Ш¬Щ…Ш№Щ‡', 'ШґЩ†ШЁЩ‡');
    private $MN = array('', '&#x0641;&#x0631;&#x0648;&#x0631;&#x062F;&#x064A;&#x0646;', '&#x0627;&#x0631;&#x062F;&#x064A;&#x0628;&#x0647;&#x0634;&#x062A;', '&#x062E;&#x0631;&#x062F;&#x0627;&#x062F;', '&#x062A;&#x064A;&#x0631;', '&#x0645;&#x0631;&#x062F;&#x0627;&#x062F;', '&#x0634;&#x0647;&#x0631;&#x064A;&#x0648;&#x0631;', '&#x0645;&#x0647;&#x0631;', '&#x0622;&#x0628;&#x0627;&#x0646;', '&#x0622;&#x0630;&#x0631;', '&#x062F;&#x064A;', '&#x0628;&#x0647;&#x0645;&#x0646;', '&#x0627;&#x0633;&#x0641;&#x0646;&#x062F;');
    private static function div($a, $b)
    {
        return (int)($a / $b);
    }
    private $g_days_in_month = array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
    private $j_days_in_month = array(31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29);
    private $j_month_name = array("", "Farvardin", "Ordibehesht", "Khordad", "Tir","Mordad", "Shahrivar", "Mehr", "Aban", "Azar","Dey", "Bahman", "Esfand");
    public static  function mtos($date, $out = "full")
    {
        $datea = preg_split("/-/", $date, 5);
        $g_y = $datea[0];
        $g_d = $datea[2];
        $g_m = $datea[1];
        if (!$g_y) {
            $g_y = date("Y");
            $g_d = date("j");
            $g_m = date("m");
        }
        $Wday = date("w", mktime(0, 0, 0, $g_m, $g_d, $g_y));//Day of week
        global $g_days_in_month;
        global $j_days_in_month;

        $gy = $g_y - 1600;
        $gm = $g_m - 1;
        $gd = $g_d - 1;

        $g_day_no = 365 * $gy + self::div($gy + 3, 4) - self::div($gy + 99, 100) + self::div($gy + 399, 400);

        for ($i = 0; $i < $gm; ++$i)
            $g_day_no += $g_days_in_month[$i];
        if ($gm > 1 && (($gy % 4 == 0 && $gy % 100 != 0) || ($gy % 400 == 0)))
            /* leap and after Feb */
            ++$g_day_no;
        $g_day_no += $gd;

        $j_day_no = $g_day_no - 79;

        $j_np = self::div($j_day_no, 12053);
        $j_day_no %= 12053;

        $jy = 979 + 33 * $j_np + 4 * self::div($j_day_no, 1461);

        $j_day_no %= 1461;

        if ($j_day_no >= 366) {
            $jy += self::div($j_day_no - 1, 365);
            $j_day_no = ($j_day_no - 1) % 365;
        }

        for ($i = 0; $i < 11 && $j_day_no >= $j_days_in_month[$i]; ++$i) {
            $j_day_no -= $j_days_in_month[$i];
        }
        $jm = $i + 1;
        $jd = $j_day_no + 1;


//   return array($jy, $jm, $jd);
        global $WDN, $MN;
//return  $WDN[$Wday]." $jd ".$MN[$jm]." $jy ";
        if ($out == 'short') {
            $jy -= 1300;
//		return  en2fa("$jy/$jm/$jd");
            return "$jy-$jm-$jd";
        } else {
            return $WDN[$Wday] . " " . en2fa($jd) . " " . $MN[$jm] . " " . en2fa($jy) . " ";
        }
    }

    public static function get_jalali_date($gdate = 'now')
    {
        if ($gdate == 'now') {
            list($gyear, $gmonth, $gday) = preg_split('/-/', date("Y-m-d"));
        } else {
            list($gyear, $gmonth, $gday) = preg_split('/-/', $gdate);
        }
        list($jyear, $jmonth, $jday) = gregorian_to_jalali($gyear, $gmonth, $gday);
        return $jyear . "/" . $jmonth . "/" . $jday;
    }

    public static function gregorian_to_jalali($g_y, $g_m, $g_d)
    {
        $g_days_in_month = array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
        $j_days_in_month = array(31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29);


        $gy = $g_y - 1600;
        $gm = $g_m - 1;
        $gd = $g_d - 1;

        $g_day_no = 365 * $gy + self::div($gy + 3, 4) - self::div($gy + 99, 100) + self::div($gy + 399, 400);

        for ($i = 0; $i < $gm; ++$i)
            $g_day_no += $g_days_in_month[$i];
        if ($gm > 1 && (($gy % 4 == 0 && $gy % 100 != 0) || ($gy % 400 == 0)))
            /* leap and after Feb */
            $g_day_no++;
        $g_day_no += $gd;

        $j_day_no = $g_day_no - 79;

        $j_np = self::div($j_day_no, 12053); /* 12053 = 365*33 + 32/4 */
        $j_day_no = $j_day_no % 12053;

        $jy = 979 + 33 * $j_np + 4 * self::div($j_day_no, 1461); /* 1461 = 365*4 + 4/4 */

        $j_day_no %= 1461;

        if ($j_day_no >= 366) {
            $jy += self::div($j_day_no - 1, 365);
            $j_day_no = ($j_day_no - 1) % 365;
        }

        for ($i = 0; $i < 11 && $j_day_no >= $j_days_in_month[$i]; ++$i)
            $j_day_no -= $j_days_in_month[$i];
        $jm = $i + 1;
        $jd = $j_day_no + 1;

        return array($jy, $jm, $jd);
    }

    public static  function jalali_to_gregorian($j_y, $j_m, $j_d)
    {
        $g_days_in_month = array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
        $j_days_in_month = array(31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29);


        $jy = $j_y - 979;
        $jm = $j_m - 1;
        $jd = $j_d - 1;

        $j_day_no = 365 * $jy + self::div($jy, 33) * 8 + self::div($jy % 33 + 3, 4);
        for ($i = 0; $i < $jm; ++$i)
            $j_day_no += $j_days_in_month[$i];

        $j_day_no += $jd;

        $g_day_no = $j_day_no + 79;

        $gy = 1600 + 400 * self::div($g_day_no, 146097); /* 146097 = 365*400 + 400/4 - 400/100 + 400/400 */
        $g_day_no = $g_day_no % 146097;

        $leap = true;
        if ($g_day_no >= 36525) /* 36525 = 365*100 + 100/4 */ {
            $g_day_no--;
            $gy += 100 * self::div($g_day_no, 36524); /* 36524 = 365*100 + 100/4 - 100/100 */
            $g_day_no = $g_day_no % 36524;

            if ($g_day_no >= 365)
                $g_day_no++;
            else
                $leap = false;
        }

        $gy += 4 * self::div($g_day_no, 1461); /* 1461 = 365*4 + 4/4 */
        $g_day_no %= 1461;

        if ($g_day_no >= 366) {
            $leap = false;

            $g_day_no--;
            $gy += self::div($g_day_no, 365);
            $g_day_no = $g_day_no % 365;
        }

        for ($i = 0; $g_day_no >= $g_days_in_month[$i] + ($i == 1 && $leap); $i++)
            $g_day_no -= $g_days_in_month[$i] + ($i == 1 && $leap);
        $gm = $i + 1;
        $gd = $g_day_no + 1;

        return array($gy, $gm, $gd);
    }


    private static function en2fa($srting)
    {
        $num0 = "&#1776;";
        $num1 = "&#1777;";
        $num2 = "&#1778;";
        $num3 = "&#1779;";
        $num4 = "&#1780;";
        $num5 = "&#1781;";
        $num6 = "&#1782;";
        $num7 = "&#1783;";
        $num8 = "&#1784;";
        $num9 = "&#1785;";

        $stringtemp = "";
        $len = strlen($srting);
        for ($sub = 0; $sub < $len; $sub++) {
            if (substr($srting, $sub, 1) == "0") $stringtemp .= $num0;
            elseif (substr($srting, $sub, 1) == "1") $stringtemp .= $num1;
            elseif (substr($srting, $sub, 1) == "2") $stringtemp .= $num2;
            elseif (substr($srting, $sub, 1) == "3") $stringtemp .= $num3;
            elseif (substr($srting, $sub, 1) == "4") $stringtemp .= $num4;
            elseif (substr($srting, $sub, 1) == "5") $stringtemp .= $num5;
            elseif (substr($srting, $sub, 1) == "6") $stringtemp .= $num6;
            elseif (substr($srting, $sub, 1) == "7") $stringtemp .= $num7;
            elseif (substr($srting, $sub, 1) == "8") $stringtemp .= $num8;
            elseif (substr($srting, $sub, 1) == "9") $stringtemp .= $num9;
            else $stringtemp .= substr($srting, $sub, 1);

        }
        return $stringtemp;

    }
}
?>
