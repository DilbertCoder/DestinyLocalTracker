#ifndef DESTINYAPIINTERFACE_H
#define DESTINYAPIINTERFACE_H
//-----------------------------------------------------------------------------
// This class handles the interactiion between the application and the Destiny
// web api
//-----------------------------------------------------------------------------

// Qt includes
#include <QObject>

// Standard C++ includes
#include <string>

class destinyApiInterface : public QObject
{
    Q_OBJECT
public:
    explicit destinyApiInterface(QObject *parent = nullptr);


signals:


private:
    const std::string& m_BaseApiUrl = "todo";
};

#endif // DESTINYAPIINTERFACE_H
