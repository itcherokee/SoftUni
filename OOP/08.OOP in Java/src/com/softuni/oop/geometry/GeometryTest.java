package com.softuni.oop.geometry;

import java.util.Arrays;

public class GeometryTest {

    public static void main(String[] args) {

        Shape triangle = new Triangle(new Point2D(1, 1), new Point2D(1, 2), new Point2D(10.2, 33));
        Shape rect = new Rectangle(new Point2D(10, 10), 20, 10);
        Shape circle = new Circle(new Point2D(-10, 10), 10);
        Shape pyramid = new SquarePyramid(new Point3D(-7.2, 12, 10), 20, 29.1);
        Shape cuboid = new Cuboid(new Point3D(4.3, 2, -1), 10, 5, 3);
        Shape sphere = new Sphere(new Point3D(4.3, 22, -1), 1);

        Shape[] mathObjects = new Shape[]{triangle, rect, circle, pyramid, cuboid, sphere};

        System.out.println("**********************************************************");
        System.out.println("Only VolumeMeasurable shapes (with volume over 40.00 cm3):");
        System.out.println("**********************************************************");
        Arrays.stream(mathObjects)
                .filter(shape -> shape instanceof VolumeMeasurable)
                .map(shape -> (VolumeMeasurable) shape)
                .filter(shape -> shape.getVolume() > 40.00)
                .forEach(System.out::println);

        System.out.println("**************************************************");
        System.out.println("Only Plane shapes (sorted by perimeter ascending):");
        System.out.println("**************************************************");
        Arrays.stream(mathObjects)
                .filter(shape -> shape instanceof PlaneShape)
                .map(shape -> (PlaneShape) shape)
                .sorted((shapeOne, shapeTwo) -> Double.compare(shapeOne.getPerimeter(), shapeTwo.getPerimeter()))
                .forEach(System.out::println);
    }
}
