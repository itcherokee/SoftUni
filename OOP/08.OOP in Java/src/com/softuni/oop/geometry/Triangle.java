package com.softuni.oop.geometry;

public class Triangle extends PlaneShape {
    public Triangle(Point2D vertexA, Point2D vertexB, Point2D vertexC) {
        super(vertexA);
        if (vertexB == null || vertexC == null) {
            throw new NullPointerException("Invalid vortex - one or more are null.");
        }

        this.addVertex(vertexB);
        this.addVertex(vertexC);

        if (!isValid()) {
            throw new IllegalArgumentException("Provided vertices cannot form a triangle.");
        }
    }

    @Override
    public double getArea() {
        double halfPerimeter = this.getPerimeter() / 2;

        return Math.sqrt(halfPerimeter * (halfPerimeter - this.getSideA()) *
                (halfPerimeter - this.getSideB()) * (halfPerimeter - this.getSideC()));
    }

    @Override
    public double getPerimeter() {
        return this.getSideA() + this.getSideB() + this.getSideC();
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append("Shape type: Triangle\n");
        output.append(super.toString());

        return output.toString();
    }

    private boolean isValid() {
        return !(this.getSideA() + this.getSideB() <= this.getSideC() ||
                this.getSideA() + this.getSideC() <= this.getSideB() ||
                this.getSideB() + this.getSideC() <= this.getSideA());
    }

    private double getSideA() {
        return this.getDistance((Point2D) this.getVertex(0), (Point2D) this.getVertex(1));
    }

    private double getSideB() {
        return this.getDistance((Point2D) this.getVertex(1), (Point2D) this.getVertex(2));
    }

    private double getSideC() {
        return this.getDistance((Point2D) this.getVertex(2), (Point2D) this.getVertex(0));
    }

    private double getDistance(Point2D vertexA, Point2D vertexB) {
        if (vertexA == null || vertexB == null) {
            throw new NullPointerException("One or both of the vertices are null.");
        }

        double xComponent = Math.pow(vertexA.getX() - vertexB.getX(), 2);
        double yComponent = Math.pow(vertexA.getY() - vertexB.getY(), 2);

        return Math.sqrt(xComponent + yComponent);
    }
}
