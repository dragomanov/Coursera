(* Homework3 Simple Test*)
(* These are basic test cases. Passing these tests does not guarantee that your code will pass the actual homework grader *)
(* To run the test, add a new line to the top of this file: use "homeworkname.sml"; *)
(* All the tests should evaluate to true. For example, the REPL should say: val test1 = true : bool *)

use "E:/Users/adragomanov/Documents/GitHub/Coursera/Programming Languages/Homework 3/hw3.sml";

val test1_1 = only_capitals ["Asdf","B","C c"] = ["Asdf","B","C c"]
val test1_2 = only_capitals ["a","B","c"] = ["B"]
val test1_3 = only_capitals ["zxvc","asdf","C"] = ["C"]
val test1_4 = only_capitals ["AASDQW","zASDSAB","_CaC", " AASD"] = ["AASDQW"]

val test2_1 = longest_string1 [] = ""
val test2_2 = longest_string1 ["A"] = "A"
val test2_3 = longest_string1 ["A","bc","C"] = "bc"
val test2_4 = longest_string1 ["","bc","cb", "", "as"] = "bc"

val test3_1 = longest_string2 [] = ""
val test3_2 = longest_string2 ["A"] = "A"
val test3_3 = longest_string2 ["A","bc","C"] = "bc"
val test3_4 = longest_string2 ["","bc","cb", "", "as"] = "as"

val test4a = longest_string3 ["A","bc","Cc"] = "bc"

val test4b = longest_string4 ["Ac","Bc","C"] = "Bc"

val test5 = longest_capitalized ["A","bc","C"] = "A";

val test6 = rev_string "abc" = "cba";

val test7 = first_answer (fn x => if x > 3 then SOME x else NONE) [1,2,3,4,5] = 4
(*
val test8 = all_answers (fn x => if x = 1 then SOME [x] else NONE) [2,3,4,5,6,7] = NONE

val test9a = count_wildcards Wildcard = 1

val test9b = count_wild_and_variable_lengths (Variable("a")) = 1

val test9c = count_some_var ("x", Variable("x")) = 1;

val test10 = check_pat (Variable("x")) = true

val test11 = match (Const(1), UnitP) = NONE

val test12 = first_match Unit [UnitP] = SOME []

*)