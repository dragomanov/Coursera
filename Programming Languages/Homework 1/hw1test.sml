(* Homework1 Simple Test *)
(* These are basic test cases. Passing these tests does not guarantee that your code will pass the actual homework grader *)
(* To run the test, add a new line to the top of this file: use "homeworkname.sml"; *)
(* All the tests should evaluate to true. For example, the REPL should say: val test1 = true : bool *)

use "E:/Users/adragomanov/Documents/GitHub/Coursera/Programming Languages/Homework 1/hw1.sml";

val test1_1 = is_older((1,2,3),(2,3,4)) = true
val test1_2 = is_older((1,2,3),(1,2,4)) = true
val test1_3 = is_older((1,2,3),(1,2,3)) = false

val test2_1 = number_in_month([(2012,2,28),(2013,12,1)],2) = 1
val test2_2 = number_in_month([(2012,12,28),(2013,12,1)],12) = 2
val test2_3 = number_in_month([(2012,2,28),(2013,12,1)],11) = 0

val test3_1 = number_in_months([(2012,2,28),(2013,12,1),(2011,3,31),(2011,4,28)],[2,3,4]) = 3
val test3_2 = number_in_months([(2012,2,28),(2013,12,1),(2011,3,31),(2011,4,28)],[1,5,8]) = 0
val test3_3 = number_in_months([(2012,2,28),(2013,2,1),(2011,3,31),(2011,4,28)],[1,3,4]) = 2

val test4_1 = dates_in_month([(2012,2,28),(2013,12,1),(2011,3,31),(2011,4,28)],2) = [(2012,2,28)]
val test4_2 = dates_in_month([(2012,2,28),(2013,12,1),(2011,3,31),(2011,4,28)],11) = []
val test4_3 = dates_in_month([(2012,4,28),(2013,12,1),(2011,3,31),(2011,4,28)],4) = [(2012,4,28),(2011,4,28)]

val test5_1 = dates_in_months([(2012,2,28),(2013,12,1),(2011,3,31),(2011,4,28)],[2,3,4]) = [(2012,2,28),(2011,3,31),(2011,4,28)]
val test5_2 = dates_in_months([(2012,2,28),(2013,4,1),(2011,3,31),(2011,4,28)],[2,3,4]) = [(2012,2,28),(2011,3,31),(2013,4,1),(2011,4,28)]
val test5_3 = dates_in_months([(2012,2,28),(2013,12,1),(2011,3,31),(2011,4,28)],[2,3,4]) = [(2012,2,28),(2011,3,31),(2011,4,28)]

val test6_1 = get_nth(["hi", "there", "how", "are", "you"], 2) = "there"
val test6_2 = get_nth(["hi", "there", "how", "are", "you"], 4) = "are"
val test6_3 = get_nth(["hi", "there", "how", "", "you"], 4) = ""

val test7_1 = date_to_string((2013, 6, 1)) = "June 1, 2013"
val test7_2 = date_to_string((2014, 1, 13)) = "January 13, 2014"
val test7_3 = date_to_string((2013, 12, 31)) = "December 31, 2013"

val test8_1 = number_before_reaching_sum(10, [1,2,3,4,5]) = 3
val test8_2 = number_before_reaching_sum(12, [11,2,3,4,5]) = 1
val test8_3 = number_before_reaching_sum(11, [1,2,3,4,5]) = 4

val test9_1 = what_month(70) = 3
val test9_2 = what_month(1) = 1
val test9_3 = what_month(365) = 12

val test10_1 = month_range(31, 34) = [1,2,2,2]
val test10_2 = month_range(59, 60) = [2,3]

val test11_1 = oldest([(2012,2,28),(2011,3,31),(2011,4,28)]) = SOME (2011,3,31)
val test11_2 = oldest([]) = NONE
val test11_3 = oldest([(2011,4,28),(2012,2,28)]) = SOME (2011,4,28)
