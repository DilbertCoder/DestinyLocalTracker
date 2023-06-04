#include "destinylocaltracker.h"

#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    DestinyLocalTracker w;
    w.show();
    return a.exec();
}
