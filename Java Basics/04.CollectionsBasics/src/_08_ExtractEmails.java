// Task 8:	Write a program to extract all email addresses from given text. 
//			The text comes at the first input line. Print the emails in 
//			the output, each at a separate line. Emails are considered 
//			to be in format <user>@<host>,.

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _08_ExtractEmails {

	private static Pattern emailPattern = Pattern.compile(
			"[^(-\\._%)][_%A-Za-z0-9-]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})");

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String input = reader.nextLine();
		Matcher matches = emailPattern.matcher(input);
		while (matches.find()) {
		    System.out.println(matches.group());
		}
	}
}
