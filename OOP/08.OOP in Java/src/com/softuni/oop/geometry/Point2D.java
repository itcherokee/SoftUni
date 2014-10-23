package com.softuni.oop.geometry;

public class Point2D implements Point {
    private double x;
    private double y;

    public Point2D(double coordinateX, double coordinateY) {
        this.setY(coordinateY);
        this.setX(coordinateX);
    }

    public double getY() {
        return this.y;
    }

    public void setY(double coordinateY) {
        this.y = coordinateY;
    }

    public double getX() {
        return this.x;
    }

    public void setX(double coordinateX) {
        this.x = coordinateX;
    }

    @Override
    public String toString() {
        return String.format("%s,%s", this.getX(), this.getY());
    }
}
