// Task 2: 	Write a program that enters 3 points in the plane (as integer x and y coordinates), 
//			calculates and prints the area of the triangle composed by these 3 points. 
//			Round the result to a whole number. In case the three points do not form a triangle, 
//			print "0" as result. 

import java.util.Locale;
import java.util.Scanner;

public class TriangleArea {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		System.out.print("Enter the coordinates (x,y) of each point splited by space.");
		System.out.println();
		String[] numbering = { "first", "second", "third" };
		int[][] points = new int[3][];
		double[] sides = new double[3];
		for (int row = 0; row < 3; row++) {
			System.out.printf("Enter %s point coordinates: ", numbering[row]);
			int xCoordinate = input.nextInt(10);
			int yCoordinate = input.nextInt(10);
			points[row] = new int[] { xCoordinate, yCoordinate };
		}

		// Calculate the sides' length
		for (int index = 0; index < sides.length; index++) {
			int deltaX = points[index][0] - points[index < sides.length - 1 ? index + 1 : index - index][0];
			int deltaY = points[index][1] - points[index < sides.length - 1 ? index + 1 : index - index][1];
			sides[index] = Math.sqrt(deltaX * deltaX + deltaY * deltaY);
		}

		double halfPerimeter = (sides[0] + sides[1] + sides[2]) / 2;
		double area = Math.sqrt(halfPerimeter *
				(halfPerimeter - sides[0]) * (halfPerimeter - sides[1]) * (halfPerimeter - sides[2]));
		System.out.printf("The area of the triangle is: %s", Math.round(area));
	}
}
