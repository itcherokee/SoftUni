// Task 7:	Write a program to calculate the difference between two dates in number of days. 
//			The dates are entered at two consecutive lines in format day-month-year. 
//			Days are in range [1…31]. Months are in range [1…12]. Years are in range [1900…2100]. 

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class _07_DaysBetweenTwoDates {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String firstDate = reader.next();
		String secondDate = reader.next();
		SimpleDateFormat formatedDate = new SimpleDateFormat("dd-MM-yyyy");
		Date dateOne;
		Date dateTwo;
		try {
			dateOne = formatedDate.parse(firstDate);
			dateTwo = formatedDate.parse(secondDate);
			long diff = dateTwo.getTime() - dateOne.getTime();
			int differenceInDays = (int) (diff / (24 * 1000 * 60 * 60));
			System.out.println(differenceInDays);
		} catch (ParseException e) {
			System.out.println("There was a parsing error during conversion of entered date to valid Java date!");
		}
	}
}
