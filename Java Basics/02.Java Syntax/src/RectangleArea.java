// Task 1:	Write a program that enters the sides of a rectangle (two integers a and b) 
//			and calculates and prints the rectangle's area.

import java.util.Scanner;

public class RectangleArea {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		System.out.print("Enter the size of the first side: ");
		int sideOne = input.nextInt(10);
		System.out.print("Enter the size of the second side: ");
		int sideTwo = input.nextInt(10);
		System.out.printf("The area of the rectangle is: %d", sideOne * sideTwo); 
	}
}
