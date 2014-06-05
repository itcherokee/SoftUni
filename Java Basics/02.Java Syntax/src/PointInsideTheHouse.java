// Task 9:	Write a program to check whether a point is inside or outside the house below. 
//			The point is given as a pair of floating-point numbers, separated by a space. 
//			Your program should print "Inside" or "Outside". 

import java.util.Locale;
import java.util.Scanner;

public class PointInsideTheHouse {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		PointInsideTheHouse house = new PointInsideTheHouse();
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		System.out.print("Enter the coordinates (x,y) of point: ");
		Point point = house.new Point(input.nextDouble(), input.nextDouble());

		// Figure House coordinates definition according to task
		// Points of house definition
		Point pointA = house.new Point(12.5, 8.5);
		Point pointB = house.new Point(17.5, 3.5);
		Point pointC = house.new Point(22.5, 8.5);
		Point pointD = house.new Point(22.5, 13.5);
		Point pointE = house.new Point(20, 13.5);
		Point pointF = house.new Point(20, 8.5);
		Point pointG = house.new Point(17.5, 8.5);
		Point pointH = house.new Point(17.5, 13.5);
		Point pointI = house.new Point(12.5, 13.5);

		// Walls of house definition
		Line lineAB = house.new Line(pointA, pointB);
		Line lineBC = house.new Line(pointB, pointC);
		Line lineCA = house.new Line(pointC, pointA);
		Line lineAG = house.new Line(pointA, pointG);
		Line lineCD = house.new Line(pointC, pointD);
		Line lineDE = house.new Line(pointD, pointE);
		Line lineFC = house.new Line(pointF, pointC);
		Line lineEF = house.new Line(pointE, pointF);
		Line lineGH = house.new Line(pointG, pointH);
		Line lineHI = house.new Line(pointH, pointI);
		Line lineIA = house.new Line(pointI, pointA);

		System.out.print("Point is: ");
		if ((isPointInside(point, lineAB) && isPointInside(point, lineBC) && isPointInside(point, lineCA)) ||
				(isPointInside(point, lineAG) && isPointInside(point, lineGH) &&
						isPointInside(point, lineHI) && isPointInside(point, lineIA)) ||
				(isPointInside(point, lineFC) && isPointInside(point, lineCD) &&
						isPointInside(point, lineDE) && isPointInside(point, lineEF)))
		{
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}

	private static boolean isPointInside(Point point, Line line) {
		double determinant = (line.end.x - line.start.x) * (point.y - line.start.y) -
				(line.end.y - line.start.y) * (point.x - line.start.x);
		return determinant >= 0 ? true : false;
	}

	public class Point {
		public double x;
		public double y;

		public Point(double coordX, double coordY) {
			x = coordX;
			y = coordY;
		}
	}

	public class Line {
		public Point start;
		public Point end;

		public Line(Point startPoint, Point endPoint) {
			start = startPoint;
			end = endPoint;
		}
	}

}
