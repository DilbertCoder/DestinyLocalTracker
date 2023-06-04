#include "destinylocaltracker.h"
#include "./ui_destinylocaltracker.h"

DestinyLocalTracker::DestinyLocalTracker(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::DestinyLocalTracker)
{
    ui->setupUi(this);
}

DestinyLocalTracker::~DestinyLocalTracker()
{
    delete ui;
}

