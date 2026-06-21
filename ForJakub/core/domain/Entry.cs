using ForJakub.core.interfaces;

namespace ForJakub.core.domain;

internal readonly record struct Entry
    (Player Player, double PointsGain, int PlayerPlacement)
    : IData;
