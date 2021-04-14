# Saffron

An open-source high-performance blog engine intended to closely work with machine learning and easily customizable layout.

## Caution

It's an under dev project.


## Faster Debugging

If you think that all of your `npm` packages are up-to-date, head over to `Saffron.csproj` and comment out the following portion or a specific command.

```XML
<Target Name="PreBuild" BeforeTargets="PreBuildEvent">
  <Exec Command="npm install" WorkingDirectory="NpmJs" />
  <Exec Command="npm run build" WorkingDirectory="NpmJs" />
  <Exec Command="npm run buildtaliwind" WorkingDirectory="NpmJs" />
  ...
</Target>
```

**Note:** These commands need to be executed at least one time to run the application properly.

## Licence and attributes

### SVG Providers

- [unDraw](https://undraw.co)

### Icon
- [Flaticon](www.flaticon.com)

