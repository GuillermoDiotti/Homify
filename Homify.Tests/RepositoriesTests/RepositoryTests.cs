using FluentAssertions;
using Homify.DataAccess.Contexts;
using Homify.DataAccess.Contexts.TestContext;
using Homify.DataAccess.Repositories;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class RepositoryTests
{
    private readonly TestDbContext _context = HomifyDbContext.BuildTestDbContext();
    private readonly Repository<EntityTest> _repository;

    public RepositoryTests()
    {
        _repository = new Repository<EntityTest>(_context);
    }

    [TestInitialize]
    public void Setup()
    {
        _context.Database.EnsureCreated();
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Database.EnsureDeleted();
    }

    #region Add
    #region Success
    [TestMethod]
    public void Add_WhenInfoIsProvided_ShouldAddedToDatabase()
    {
        var entity = new EntityTest("some name");

        _repository.Add(entity);

        using var otherContext = HomifyDbContext.BuildTestDbContext();

        var entitiesSaved = otherContext.EntitiesTest.ToList();

        entitiesSaved.Count.Should().Be(1);

        var entitySaved = entitiesSaved[0];
        entitySaved.Id.Should().Be(entity.Id);
        entitySaved.Name.Should().Be(entity.Name);
    }
    #endregion
    #endregion

    #region GetAll
    [TestMethod]
    public void GetAll_WhenExistOnlyOne_ShouldReturnOne()
    {
        var expectedEntity = new EntityTest
        {
            Name = "dummy"
        };
        using var context = HomifyDbContext.BuildTestDbContext();
        context.Add(expectedEntity);
        context.SaveChanges();

        var entitiesSaved = _repository.GetAll();

        entitiesSaved.Count.Should().Be(1);

        var entitySaved = entitiesSaved[0];
        entitySaved.Id.Should().Be(expectedEntity.Id);
        entitySaved.Name.Should().Be(expectedEntity.Name);
    }
    #endregion
}
