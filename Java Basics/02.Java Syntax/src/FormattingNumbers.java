// Task 6.	Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), 
//			a floating-point b and a floating-point c and prints them in 4 
//			virtual columns on the console. Each column should have a width 
//			of 10 characters. The number a should be printed in hexadecimal, 
//			left aligned; then the number a should be printed in binary form, 
//			padded with zeroes, then the number b should be printed with 2 digits 
//			after the decimal point, right aligned; the number c should be printed 
//			with 3 digits after the decimal point, left aligned.

import java.util.Locale;
import java.util.Scanner;

public class FormattingNumbers {
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		System.out.print("Enter three numbers (int/float/float): ");
		int decimalNumber = reader.nextInt();
		double floatNumberOne = reader.nextDouble();
		double floatNumberTwo = reader.nextDouble();
		String binary = Integer.toBinaryString(decimalNumber).replace(' ', '0');
		System.out.printf("|%-10H|%10s|%10.2f|%-10.3f|", decimalNumber, binary, floatNumberOne, floatNumberTwo);
	}
}
