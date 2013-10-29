(* Dan Grossman, Coursera PL, HW2 Provided Code *)

(* if you use this function to compare two strings (returns true if the same
   string), then you avoid several of the functions in problem 1 having
   polymorphic types that may be confusing *)
fun same_string(s1 : string, s2 : string) =
    s1 = s2

(* put your solutions for problem 1 here *)

fun all_except_option(s1, slist) =
	case slist of
		[] => NONE
	  | x::xs => if same_string(s1, x) 
				 then SOME xs 
				 else (case all_except_option(s1, xs) of SOME y => SOME (x::y) | _ => NONE)

fun get_substitutions1(sllist, s) =
	case sllist of
		[] => []
	  | x::xs => case all_except_option(s, x) of
				 NONE => get_substitutions1(xs, s)
			   | SOME y => y @ get_substitutions1(xs, s)

fun get_substitutions2(sllist, s) =
	case sllist of
		[] => []
	  | x::xs => case all_except_option(s, x) of
				 NONE => get_substitutions1(xs, s)
			   | SOME y => y @ get_substitutions1(xs, s)


(* you may assume that Num is always used with values 2, 3, ..., 10
   though it will not really come up *)
datatype suit = Clubs | Diamonds | Hearts | Spades
datatype rank = Jack | Queen | King | Ace | Num of int 
type card = suit * rank

datatype color = Red | Black
datatype move = Discard of card | Draw 

exception IllegalMove

(* put your solutions for problem 2 here *)

fun card_color(s, r) =
	case s of
		Clubs => Black
	  | Spades => Black
	  | Diamonds => Red
	  | Hearts => Red

fun card_value(s, r) =
	case r of
		Ace => 11
	  |	Num x => x
	  |	_ => 10
	  
fun remove_card(cs, c, e) =
	case cs of
		[] => raise e
	  | c'::cs' => if c = c' then cs' else c' :: remove_card(cs', c, e)

fun all_same_color(cs) =
	case cs of
		[] => true
	  | _::[] => true
	  | ca::cb::cs' => (card_color(ca) = card_color(cb) andalso all_same_color(cb::cs'))

fun sum_cards(cs) =
	let fun sum_rest(cs, acc) =
		case cs of
			[] => acc
		  | c::cs' => sum_rest(cs', acc + card_value(c)) 
	in
		sum_rest(cs, 0)
	end

fun score(cs, goal) =
	let val sum = sum_cards(cs) 
		val pscore = if sum > goal
			then 3 * (sum - goal)
			else goal - sum
	in
		if all_same_color(cs)
		then pscore div 2
		else pscore
	end

fun officiate(cs, move, goal) =
	let fun player_move(pcs, cs, move, goal) =
		case move of
			[] => score(pcs, goal)
		  | Discard c :: ms => player_move(remove_card(pcs, c, IllegalMove), cs, ms, goal)
		  | Draw :: ms => case cs of
						  [] => score(pcs, goal) 
						| c::cs' => if sum_cards(c::pcs) > goal
									then score(c::pcs, goal)
									else player_move(c::pcs, cs', ms, goal)
	in
		player_move([], cs, move, goal)
	end
