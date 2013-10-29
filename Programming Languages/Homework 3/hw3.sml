(* Coursera Programming Languages, Homework 3, Provided Code *)

exception NoAnswer

datatype pattern = Wildcard
		 | Variable of string
		 | UnitP
		 | ConstP of int
		 | TupleP of pattern list
		 | ConstructorP of string * pattern

datatype valu = Const of int
	      | Unit
	      | Tuple of valu list
	      | Constructor of string * valu

fun g f1 f2 p =
    let 
	val r = g f1 f2 
    in
	case p of
	    Wildcard          => f1 ()
	  | Variable x        => f2 x
	  | TupleP ps         => List.foldl (fn (p,i) => (r p) + i) 0 ps
	  | ConstructorP(_,p) => r p
	  | _                 => 0
    end

(**** for the challenge problem only ****)

datatype typ = Anything
	     | UnitT
	     | IntT
	     | TupleT of typ list
	     | Datatype of string

(**** you can put all your code here ****)

fun only_capitals(string_list) =
	List.filter (fn x => Char.isUpper(String.sub(x, 0))) string_list

fun longest_string1(string_list) =
	List.foldl (fn (x, y) => if String.size x > String.size y then x else y) "" string_list

fun longest_string2(string_list) =
	List.foldl (fn (x, y) => if String.size x >= String.size y then x else y) "" string_list

fun longest_string_helper f string_list =
	List.foldl f "" string_list
	
fun longest_string3(string_list) =
	longest_string_helper (fn (x, y) => if String.size x > String.size y then x else y) string_list

fun longest_string4(string_list) =
	longest_string_helper (fn (x, y) => if String.size x >= String.size y then x else y) string_list

fun longest_capitalized(string_list) =
	let val f = longest_string1 o only_capitals
	in f string_list
	end

fun rev_string str =
	(implode o List.rev o explode) str

fun first_answer f xs =
	case xs of
		[] => raise NoAnswer
	  | x::xs' => case f x of
			NONE => first_answer f xs'
		  |	SOME y => y

















