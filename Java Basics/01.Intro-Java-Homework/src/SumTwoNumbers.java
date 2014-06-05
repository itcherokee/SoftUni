// Task 6:	Write a program SumTwoNumbers.java that enters two integers 
//			from the console, calculates and prints their sum. 

import java.util.Scanner;

public class SumTwoNumbers {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		System.out.print("Enter first number: ");
		int sum = scanner.nextInt();
		System.out.print("Enter second number: ");
		sum += scanner.nextInt();
		System.out.printf("The sum of both numbers is %s", sum);
	}
}
