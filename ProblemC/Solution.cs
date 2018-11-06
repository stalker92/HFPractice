using Priority_Queue;
using System;
using System.Collections.Generic;

namespace ProblemC
{
    public class Solution
    {
        private readonly int n;

        private readonly char[,] map;

        private readonly int[,] heights;

        private PlaceData[] placeDatas;

        private List<int> houses;

        private int postOffice;

        private SimplePriorityQueue<int> priorityQueue;

        public Solution(int n, char[,] map, int[,] heights)
        {
            this.n = n;
            this.map = map;
            this.heights = heights;
        }

        public int Solve()
        {
            Init();

            while (priorityQueue.Count > 0)
            {
                int place = priorityQueue.Dequeue();

                List<int> neighbours = GetNeighbourPlaces(place);

                foreach (int neighbour in neighbours)
                {
                    int routeMinH = placeDatas[place].RouteMinH;
                    int routeMaxH = placeDatas[place].RouteMaxH;
                    
                    if (placeDatas[neighbour].H < routeMinH)
                    {
                        routeMinH = placeDatas[neighbour].H;
                    }

                    if (placeDatas[neighbour].H > routeMaxH)
                    {
                        routeMaxH = placeDatas[neighbour].H;
                    }

                    int routeDiff = Math.Abs(routeMaxH - routeMinH);

                    if (routeDiff < placeDatas[neighbour].RouteHeightDiff)
                    {
                        placeDatas[neighbour].RouteHeightDiff = routeDiff;
                        placeDatas[neighbour].PreviousPlace = place;

                        placeDatas[neighbour].RouteMinH = routeMinH;
                        placeDatas[neighbour].RouteMaxH = routeMaxH;

                        priorityQueue.Enqueue(neighbour, routeDiff);
                    }
                }
            }

            return GetTotalHeightDifference();
        }

        private void Init()
        {
            placeDatas = new PlaceData[n * n];

            priorityQueue = new SimplePriorityQueue<int>();

            houses = new List<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int nodeIndex = (i * n) + j;

                    placeDatas[nodeIndex].X = i;
                    placeDatas[nodeIndex].Y = j;
                    placeDatas[nodeIndex].H = heights[i, j];

                    placeDatas[nodeIndex].RouteMinH = Int32.MaxValue;
                    placeDatas[nodeIndex].RouteMaxH = Int32.MinValue;

                    placeDatas[nodeIndex].RouteHeightDiff = Int32.MaxValue;
                    placeDatas[nodeIndex].PreviousPlace = -1;
                    
                    if (map[i, j] == 'P')
                    {
                        placeDatas[nodeIndex].RouteHeightDiff = 0;
                        placeDatas[nodeIndex].RouteMinH = heights[i, j];
                        placeDatas[nodeIndex].RouteMaxH = heights[i, j];

                        postOffice = nodeIndex;

                        priorityQueue.Enqueue(nodeIndex, 0);
                    }
                    else if (map[i, j] == 'K')
                    {
                        houses.Add(nodeIndex);
                    }
                }
            }
        }

        private List<int> GetNeighbourPlaces(int place)
        {
            int y = place % n;
            int x = place / n;

            List<int> neigbours = new List<int>(9);

            if (x > 0)
            {
                if (y > 0)
                {
                    neigbours.Add(place - n - 1);
                }

                neigbours.Add(place - n);

                if (y < (n - 1))
                {
                    neigbours.Add(place - n + 1);
                }
            }

            if (y > 0)
            {
                neigbours.Add(place - 1);
            }

            if (y < (n - 1))
            {
                neigbours.Add(place + 1);
            }

            if (x < (n - 1))
            {
                if (y > 0)
                {
                    neigbours.Add(place + n - 1);
                }

                neigbours.Add(place + n);

                if (y < (n - 1))
                {
                    neigbours.Add(place + n + 1);
                }
            }

            return neigbours;
        }

        private int GetTotalHeightDifference()
        {
            int maxHouseRouteHeight = placeDatas[postOffice].H;
            int minHouseRouteHeight = placeDatas[postOffice].H;

            foreach (int house in houses)
            {
                if (placeDatas[house].RouteMaxH > maxHouseRouteHeight)
                {
                    maxHouseRouteHeight = placeDatas[house].RouteMaxH;
                }

                if (placeDatas[house].RouteMinH < minHouseRouteHeight)
                {
                    minHouseRouteHeight = placeDatas[house].RouteMinH;
                }
            }

            return Math.Abs(maxHouseRouteHeight - minHouseRouteHeight);
        }
    }
}