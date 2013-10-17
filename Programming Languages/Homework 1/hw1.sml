fun is_older(d1 : int * int * int, d2 : int * int * int) =
	if #1 d1 < #1 d2
	then true
	else if #1 d1 > #1 d2
	then false
	else if #2 d1 < #2 d2
	then true
	else if #2 d1 > #2 d2
	then false
	else if #3 d1 < #3 d2
	then true
	else false

fun number_in_month(dates : (int * int * int) list, month : int) =
	if null dates
	then 0
	else
		let val ans = number_in_month(tl dates, month)
		in
			if (#2 (hd dates) = month)
			then ans + 1
			else ans
		end

fun number_in_months(dates : (int * int * int) list, months : int list) =
	if null months
	then 0
	else number_in_month(dates, hd months) + number_in_months(dates, tl months)

fun dates_in_month(dates : (int * int * int) list, month : int) =
	if null dates
	then []
	else
		let val ans = dates_in_month(tl dates, month)
		in
			if (#2 (hd dates) = month)
			then hd dates :: ans
			else ans
		end

fun dates_in_months(dates : (int * int * int) list, months : int list) =
	if null months
	then []
	else dates_in_month(dates, hd months) @ dates_in_months(dates, tl months)
	
fun get_nth(strings : string list, n : int) =
	if n = 1
	then hd strings
	else get_nth(tl strings, n - 1)
	
fun date_to_string(date : int * int * int) =
	let val months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]
	in
		get_nth(months, #2 date) ^ " " ^ Int.toString(#3 date) ^ ", " ^ Int.toString(#1 date)
	end
	
fun number_before_reaching_sum(sum : int, nums : int list) = 
	let 
		fun first_n_elems(sum : int, nums : int list, ans : int) = 
			if sum - hd nums <= 0
			then ans
			else first_n_elems(sum - hd nums, tl nums, ans + 1)
	in
		first_n_elems(sum, nums, 0)
	end
	
fun what_month(num : int) = 
	let 
		val months = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
		fun what_month_ans(num : int, months : int list, month : int) =
			if num - hd months <= 0
			then month
			else what_month_ans(num - hd months, tl months, month + 1)
	in
		what_month_ans(num, months, 1)
	end
	
fun month_range(fromto : int * int) =
	if #1 fromto > #2 fromto
	then []
	else what_month(#1 fromto) :: month_range((#1 fromto) + 1, #2 fromto)
	
fun oldest(dates : (int * int * int) list) =
	if null dates
	then NONE
	else let
		fun oldest_helper(oldest_date : (int * int * int), dates : (int * int * int) list) =
			if null dates
			then SOME oldest_date
			else if is_older(oldest_date, hd dates)
			then oldest_helper(oldest_date, tl dates)
			else oldest_helper(hd dates, tl dates)
		in
			oldest_helper(hd dates, tl dates)
		end
	
	
	
	
	
	
	
	
	
	