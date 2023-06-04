#ifndef DESTINYLOCALTRACKER_H
#define DESTINYLOCALTRACKER_H

#include <QMainWindow>

QT_BEGIN_NAMESPACE
namespace Ui { class DestinyLocalTracker; }
QT_END_NAMESPACE

class DestinyLocalTracker : public QMainWindow
{
    Q_OBJECT

public:
    DestinyLocalTracker(QWidget *parent = nullptr);
    ~DestinyLocalTracker();

private:
    Ui::DestinyLocalTracker *ui;
};
#endif // DESTINYLOCALTRACKER_H
