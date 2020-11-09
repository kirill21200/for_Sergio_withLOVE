using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.Zoom = 15;
            gMapControl1.Position = new PointLatLng(55.9943489195581, 92.7975721657276);

            var markersOverlay = new GMapOverlay("markers");
            var marker = new GMarkerGoogle(new PointLatLng(55.9943489195581, 92.7975721657276), GMarkerGoogleType.green);
            markersOverlay.Markers.Add(marker);

            var polyOverlay = new GMapOverlay("polygons");
            var points = new List<PointLatLng>
            {
                new PointLatLng(55.996032, 92.793208),
                new PointLatLng(55.996050, 92.796673),
                new PointLatLng(55.994712, 92.796705),
                new PointLatLng(55.994754, 92.793261)
            };

            var polygon = new GMapPolygon(points, "mypolygon")
            {
                Fill = new SolidBrush(Color.FromArgb(50, Color..Red)),
                Stroke = new Pen(Color.Red, 1)
            };

            polyOverlay.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyOverlay);

            var db = new DataClasses1DataContext();
            //db.Coordinate.InsertOnSubmit(new Coordinate() { Latitude = 55.978840, Longitude = 92.721260 });
            //db.Coordinate.InsertOnSubmit(new Coordinate() { Latitude = 55.977654, Longitude = 92.720881 });
            //db.SubmitChanges();

            List<Coordinate> coordinates = db.Coordinate.ToList();
            List<GMarkerGoogle> gMarkers = new List<GMarkerGoogle>();

            foreach (var c in coordinates)
            {
                gMarkers.Add(new GMarkerGoogle(new PointLatLng((double)c.Latitude, (double)c.Longitude), GMarkerGoogleType.red));
            }

            foreach (var m in gMarkers)
            {
                markersOverlay.Markers.Add(m);
            }
            gMapControl1.Overlays.Add(markersOverlay);
        }
    }
}
