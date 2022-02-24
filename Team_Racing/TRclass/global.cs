using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class global
    {
    private static string user_name;
    private static string student_name;
    private static string article_name;
    private static int user_id;
    private static int article_num;
    private static int faculty_num;
    public static string users_name
    {
        get
        {
        return user_name;
        }
        set
        {
            user_name = value;
        }
    }

    public static string students_name
    {
        get
        {
            return student_name;
        }
        set
        {
            student_name = value;
        }
    }

    public static string articles_name
    {
        get
        {
            return article_name;
        }
        set
        {
            article_name = value;
        }
    }
    public static int users_id
    {
        get
        {
            return user_id;
        }
        set
        {
            user_id = value;
        }
    }

    public static int articles_num
    {
        get
        {
            return article_num;
        }
        set
        {
            article_num = value;
        }
    }

    public static int facultys_num
    {
        get
        {
            return faculty_num; ;
        }
        set
        {
            faculty_num = value;
        }
    }

    public static string image_name
    {
        get
        {
            return image_name; ;
        }
        set
        {
            image_name = value;
        }
    }
}

