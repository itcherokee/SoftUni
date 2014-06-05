// Task 3:	Write a program to check whether a point is inside or outside of the figure below. 
//			The point is given as a pair of floating-point numbers, separated by a space. 
//			Your program should print "Inside" or "Outside". 

import java.util.Locale;
import java.util.Scanner;

public class PointsInsideFigure {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		System.out.print("Enter the coordinates (x,y) of point: ");
		double pointX = input.nextDouble();
		double pointY = input.nextDouble();

		// Figure coordinates according to task definition
		double x1 = 12.5;
		double x11 = 17.5;
		double x2 = 22.5;
		double x22 = 20.0;
		double y1 = 6.0;
		double y11 = 8.5;
		double y2 = 13.5;

		// check algorithm
		System.out.print("Point is: ");
		if ((x1 <= pointX) && (x2 >= pointX) && (y1 <= pointY) && (y2 >= pointY) &&
				!((x11 < pointX) && (x22 > pointX) && (y11 < pointY))) {
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}
}
